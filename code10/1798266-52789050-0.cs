            try
            {
                throw new AException();
            }
            catch (AException aex)
            {
                Callme(aex);
            }
            catch (BException bex)
            {
                Callme(bex);
            }
            catch (Exception ex)
            {
                Callme(ex);
            }
