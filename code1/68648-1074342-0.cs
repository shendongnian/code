    TableAttribute attribute = (TableAttribute)typeof(Table<MyTable>)
                               .GetType()
                               .GetCustomAttributes(typeof(TableAttribute), true)
                               .Single();
    string name = attribute.Name;
