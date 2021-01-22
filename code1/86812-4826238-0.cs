    var qry = from c in Entities
    		  select c;
    var lst = qry.ToList();
    
    var entity = new Entity();
    entity.EntityId= -1;
    entity.EntityDesc = "(All)";
    lst.Insert(0, entity);
    
    MyComboBox.DataSource = lst;
    MyComboBox.DisplayMember = "EntityDesc"
    MyComboBox.ValueMember = "EntityId"
