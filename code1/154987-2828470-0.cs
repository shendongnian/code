            try
            {
                return 1;
                throw new Exception();
            }
            catch (Exception e)
            {
                return 2;
            }
            finally
            {
                MessageBox.Show("3");
            }
        }
