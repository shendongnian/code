     public bool DeleteProductColour(int colid, int prd)
        {
            bool prodColourDeleted = false;
            try
            {
                var x = pcAdp.GetAllProdColours(prd).AsEnumerable().Where(y => y.ColourId == colid).FirstOrDefault();
        
                if (x != null && !string.IsnullOrEmpty(x.ColourImage))
                {
                    File.Delete(HttpContext.Current.Server.MapPath(x.ColourImage));
                }
                pcAdp.DeleteProductColour(colid);
                prodColourDeleted = true;
            }
            catch(Exception er)
            {
                ExceptionUtility.LogException(er, "Delete product colour - ProductsBLL");
            }
            return prodColourDeleted;
        }
