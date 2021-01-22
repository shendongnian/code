        /// <summary>
        /// Riempie una Entità con i valori presenti in un DataRow automaticamente.
        /// L'automatismo funzione solo se i nomi delle colonne (campi del DataBase) corrispondono ai nomi 
        /// delle properties se una Property non ha colonna del DataRow semplicemente è valorizzata al Default
        /// (come dopo una istanzizione dell'oggetto mediante "new"). Se una colonna esiste ma non c'è la 
        /// corrispondente proprietà la segnalazione dell'eccezione dipenderà dal flag: columnCanNotCorrespond
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <param name="columnCanNotCorrespond">Se true, non scatta eccezione se c'è una colonna che non è corrispondente ad una Property</param>
        /// <returns></returns>
        public static T GetEntity<T>(DataRow dr, bool columnCanNotCorrespond)
        {
            Type entityType = typeof(T);
            T entity = (T)entityType.Assembly.CreateInstance(entityType.FullName);
            if (columnCanNotCorrespond)
            {
                foreach (DataColumn dc in dr.Table.Columns)
                {
                    object columnValue = dr[dc.ColumnName];                 
                    if (entity.GetType().GetProperty(dc.ColumnName) != null) //La Property Esiste?
                        entity.GetType().GetProperty(dc.ColumnName).SetValue(entity, columnValue, null);
                }
            }
            else //Scatterà eccezione se la Property non corrisponde alla colonna!
            {
                foreach (DataColumn dc in dr.Table.Columns)
                {
                    object columnValue = dr[dc.ColumnName];                 
                    entity.GetType().GetProperty(dc.ColumnName).SetValue(entity, columnValue, null);
                }
            }
            return (T)entity;
        }
