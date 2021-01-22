        public void WriteFixedWidth(System.Xml.Linq.XElement CommandNode, DataTable Table, Stream outputStream)
        {
            StreamWriter Output = new StreamWriter(outputStream);
            int StartAt = CommandNode.Attribute("StartAt") != null ? int.Parse(CommandNode.Attribute("StartAt").Value) : 0;
            var positions = from c in CommandNode.Descendants(Namespaces.Integration + "Position")
                            orderby int.Parse(c.Attribute("Start").Value) ascending
                            select new
                            {
                                Name = c.Attribute("Name").Value,
                                Start = int.Parse(c.Attribute("Start").Value) - StartAt,
                                Length = int.Parse(c.Attribute("Length").Value),
                                Justification = c.Attribute("Justification") != null ? c.Attribute("Justification").Value.ToLower() : "left"
                            };
            int lineLength = positions.Last().Start + positions.Last().Length;
            foreach (DataRow row in Table.Rows)
            {
                StringBuilder line = new StringBuilder(lineLength);
                foreach (var p in positions)
                    line.Insert(p.Start, 
                        p.Justification == "left" ? (row.Field<string>(p.Name) ?? "").PadRight(p.Length,' ')
                                                  : (row.Field<string>(p.Name) ?? "").PadLeft(p.Length,' ') 
                        );
                Output.WriteLine(line.ToString());
            }
            Output.Flush();
        }
