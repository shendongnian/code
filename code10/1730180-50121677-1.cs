    var studentCountPerClass = (from s in db.Students
								group s by s.Class into studentsByClass    
								where studentsByClass.Any(x => x.Progress == MyEnum.Accepted)
								select new
								{
									ClassNum = studentsByClass.Key,
									Accepted = studentsByClass.Count(s => s.Progress == MyEnum.Accepted),
									NotAccepted = studentsByClass.Count(s => s.Progress < MyEnum.Accepted),
								})
								.ToList();
								
	var classCodes = studentCountPerClass.Select(x => x.ClassNum).ToList();	
	var classData = (from c in dbOther.Classes
						where classCodes.Contains(c.Class)
						select new {
							c.Class,
							// Any other data you want about the class
						})
