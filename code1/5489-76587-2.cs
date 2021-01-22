            var exceptions = new List<Exception>();
            try
            {
                this.sr.Dispose();
            }
            catch (Exception ex)
            {
                exceptions.Add(ex);
            }
            try
            {
                this.bs.Dispose();
            }
            catch (Exception ex)
            {
                exceptions.Add(ex);
            }
            try
            {
                this.fs.Dispose();
            }
            catch (Exception ex)
            {
                exceptions.Add(ex);
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
