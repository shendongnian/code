        [ResponseType(typeof(MealTrainee))]
        public IHttpActionResult PostMealTrainee([FromBody] string mealTrainee)
        {
            List<MealTrainee> meals = new List<MealTrainee>();
            using (DbContextTransaction dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    List<AddAssignMealView> mealtraiDeserializeObjects = JsonConvert.DeserializeObject<List<AddAssignMealView>>(mealTrainee);
                    foreach (var mealtraiDeserializeObject in mealtraiDeserializeObjects)
                    {
                        var mealWeek = mealtraiDeserializeObject.MealID.Select((m, i) => new
                        {
                            mealtraiDeserializeObject.TraineeID,
                            mealtraiDeserializeObject.DayOfTheWeek,
                            MealID = m,
                            MealTypes = mealtraiDeserializeObject.MealName[i],
                            MealName = mealtraiDeserializeObject.MealTypes[i]
                        }).ToList();
                     var meal = mealWeek.Select(x => new MealTrainee()
                        {
                            DayOfTheWeek = x.DayOfTheWeek,
                            MealID = x.MealID,
                            MealName = x.MealName,
                            MealType = x.MealTypes,
                            TraineeID = x.TraineeID
                        }).ToList();
                        db.MealTrainees.AddRange(meal);
                    }
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }
                    db.SaveChanges();
                    dbContextTransaction.Commit();
                    return Ok(meals);
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                    Logger.Log(e);
                    return BadRequest();
                }
            }
        }
