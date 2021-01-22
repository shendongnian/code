            try
            {
                //code
            }
            catch (FileNotFoundException e)
            {
                //Normal Code here
                #if DEBUG
                //More Detail here
                #endif
            }
            #if DEBUG
            catch (Exception e)
            {
                //handel other exceptions here
            }
            #endif
