        List<string> listvalues = new List<string>();
        listvalues = (List<string>)Session["mylist"];
        string[] strvalues = listvalues.ToArray();
        if (listvalues != null)
        {
            foreach (string strElement in listvalues)
            { 
                string[] test = strElement.ToString().Split("|".ToCharArray());
                string prodQuantity = test[0].ToString();
                foreach (GridView row in gvOrderProducts.Rows)
                {
                    prodQuantity = ((Label)row.FindControl("lblQuantity")).Text;
                }
            }
        }
    }
