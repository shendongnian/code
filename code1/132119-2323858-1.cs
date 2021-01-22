    var xml = XElement.Parse(@"<records>
     <record index=""1"">
       <property name=""Username"">Sven</property>
       <property name=""Domain"">infinity2</property>
       <property name=""LastLogon"">12/15/2009</property>
     </record>
     <record index=""2"">
       <property name=""Username"">Josephine</property>
       <property name=""Domain"">infinity3</property>
       <property name=""LastLogon"">01/02/2010</property>
     </record>
     <record index=""3"">
       <property name=""Username"">Frankie</property>
       <property name=""Domain"">wk-infinity9</property>
       <property name=""LastLogon"">10/02/2009</property>
     </record>
    </records>");
    var query = from record in xml.Elements("record")
                let properties = record.Elements("property")
                select new Record
                {
                    Index = record.Attribute("index").Value,
        Username = properties.Where(p => p.Attribute("name").Value == "Username").Single().Value,
        Domain = properties.Where(p => p.Attribute("name").Value == "Domain").Single().Value,
        LastLogon = properties.Where(p => p.Attribute("name").Value == "LastLogon").Single().Value
                };
    
    foreach(var rec in query)
    {
        Console.WriteLine("ID: {0} User:{1} Domain:{2} LastLogon:{3}", rec.Index, rec.Username, rec.Domain, rec.LastLogon);
    }
