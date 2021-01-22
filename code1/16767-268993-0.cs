        protected override void Dispose(bool disposing)
        {
            if(disposing && this.Connection != null && this.Connection.State == ConnectionState.Open)
            {
                this.Connection.Close();
                this.Connection.Dispose();
            }
            base.Dispose(disposing);
        }
