    (from a in db.Assignments
		 join b in db.Deliveryboys on a.AssignTo equals b.EmployeeId  
		 
		 //from d in eGroup.DefaultIfEmpty()
		 join  c in  db.Deliveryboys on a.DeliverTo equals c.EmployeeId into eGroup2
		 from e in eGroup2.DefaultIfEmpty()
		 where (a.Collected == false)
		 select new
		 {
			 OrderId = a.OrderId,
			 DeliveryBoyID = a.AssignTo,
			 AssignedBoyName = b.Name,
			 Assigndate = a.Assigndate,
			 Collected = a.Collected,
			 CollectedDate = a.CollectedDate,
			 CollectionBagNo = a.CollectionBagNo,
			 DeliverTo = e == null ? "Null" : e.Name,
			 DeliverDate = a.DeliverDate,
			 DeliverBagNo = a.DeliverBagNo,
			 Delivered = a.Delivered
		 });
