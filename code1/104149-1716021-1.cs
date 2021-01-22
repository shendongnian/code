        public virtual void CreateNew()
        {
            string createDDL = @"CREATE DATABASE [" + this.DBName + "]";
            this.BuildMasterConnectionString();
            this.DBConnection.Open();
            try
            {
                this.ExecuteSQLStmt(createDDL, this.DefaultSQLTimeout, null);
            }
            finally
            {
                this.DBConnection.Close();
            }
            createDDL = @"
                    CREATE TABLE AAASchemaVersion 
                    (
                        Version         int             NOT NULL,
                        DateCreated     datetime        NOT NULL,
                        Author          nvarchar(30)    NOT NULL,
                        Notes           nvarchar(MAX)   NULL 
                    );
                    ALTER TABLE AAASchemaVersion ADD CONSTRAINT PK_Version PRIMARY KEY CLUSTERED
                    (
                        Version
                    );
                    INSERT INTO AAASchemaVersion
                        (Version, DateCreated, Author, Notes)
                    VALUES
                        (0, GETDATE(), 'James Murphy', 'Empty Database')
                ";
            this.BuildConnectionString();
            this.ConnectionString += ";pooling=false";
            this.DBConnection.Open();
            try
            {
                this.ExecuteSQLStmt(createDDL, this.DefaultSQLTimeout, null);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception while creating / initialising AAASchemaVersion", ex);
            }
            finally
            {
                this.DBConnection.Close();
            }
        }
