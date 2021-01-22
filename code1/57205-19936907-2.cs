    using System.Linq;
    using System.Xml.Linq;
    using System.Collections.Generic;
    using System.Diagnostics;
    [TestMethod]
        public void Linq_XElement_Test()
        {
    
        string xml = @"<Table>
      <Record>
        <Field>Value1_1</Field>
        <Field>Value1_2</Field>
      </Record>
      <Record>
        <Field>Value2_1</Field>
        <Field>Value2_2</Field>
      </Record>
    </Table>";
        
        XElement elements = XElement.Parse(xml);
        var qryRecords = from record in elements.Elements("Record")
                      select record;
        foreach (var rec in qryRecords)
        {
            Debug.WriteLine(rec.Value);
        }
        var qryFields = from record in elements.Elements("Record")
                     from fields in record.Elements("Field")
                     select fields;
        
        foreach (var fil in qryFields)
        {
            Debug.WriteLine(fil.Value);
        }
        IEnumerable<string> list = qryFields.Select(x => x.Value);
        foreach (string item in list)
        {
            Debug.WriteLine(item);
        }
        
    }
