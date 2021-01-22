    LinqEntity item = new LinqEntity(){ Id = 1, Name = "OldName", Surname = "OldSurname"}; 
    context.LinqEntities.Attach(item);
    item.Name = "John";
    item.Surname = "Doe";
    context.SubmitChanges();
