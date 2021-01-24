                SqlDataReader dr1= command.ExecuteReader();
                ArrayList arl= new ArrayList();
                while (dr1.Read())
                {
                 arl.Add(dr1("Category_Desc"));
                }
            
                dr1.close();
             //If its a winform project use this               
               string [] str = al.ToArray(typeof(string));
                FarPoint.Win.Spread.ComboBoxCellType cb = new 
                 FarPoint.Win.Spread.ComboBoxCellType();
                cb.Items = arl;
