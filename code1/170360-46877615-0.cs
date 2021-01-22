    public static IEnumerable UserIntakeFoodEdit(FoodIntaked data)
            {
                DBContext db = new DBContext();
                var q = db.User_Food_UserIntakeFood.AsQueryable();
                var item = q.Where(f => f.PersonID == data.PersonID)
                      .Where(f => f.DateOfIntake == data.DateOfIntake)
                      .Where(f => f.MealTimeID == data.MealTimeIDOld)
                      .Where(f => f.NDB_No == data.NDB_No).FirstOrDefault();
    
                item.Amount = (decimal)data.Amount;
                item.WeightSeq = data.WeightSeq.ToString();
                item.TotalAmount = (decimal)data.TotalAmount;
    
            
                db.User_Food_UserIntakeFood.Remove(item);
                db.SaveChanges();
    
                item.MealTimeID = data.MealTimeID;//is key
    
                db.User_Food_UserIntakeFood.Add(item);
                db.SaveChanges();
    
                return "Edit";
            }
