        public static bool CanCreate(SqlDataReader dataReader)
        {
            return dataReader.ContainsColumn("RoleTemplateId") 
                && !dataReader.IsDBNull("RoleTemplateId");
        }
