        bool IsInt(double x)
        {
            try
            {
                int y = Int16.Parse(x.ToString());
                return true;
            }
            catch 
            {
                return false;
            }
        }
