            try
            {
                string a="asd";
                int s = Convert.ToInt32(a);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
