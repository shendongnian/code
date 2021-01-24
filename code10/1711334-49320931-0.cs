      if (employeeList.Count > 0)
            {
                int take = 100;
                int i = 0;
                while (employeeList.Any())
                {
                    i++;
                    var tmp = employeeList.Take(take);
                    employeeList = employeeList.Skip(take);
                    XmlSerializer mySerializer = new XmlSerializer(typeof(List<Employee>));
                    TextWriter myWriter = new StreamWriter("D:\\Employee"+i+".xml", true);
                    mySerializer.Serialize(myWriter, tmp);
                    myWriter.Close();
                }
            }
