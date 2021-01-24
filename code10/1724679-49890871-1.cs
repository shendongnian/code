    private void MyFunc(int id, int value, string name_param)
    {
        using (var db = new mydatabaseEntities())
        {
            var result = db.mytable.Where(b => b.id == id).First();
            var prop = result.GetType().GetProperty(name_param);
    
            if (prop == null)
                throw new InvalidOperationException();    //Or something appropriate
        
            prop.SetValue(result, value);
    
            db.SaveChanges(); 
        }
    }
