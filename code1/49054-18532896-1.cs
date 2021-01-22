    String sss = @"<items>
    <item>
      <id>i1</id>
       <name>item1</name>
        <subitems>
         <name>subitem1</name>
         <name>subitem2</name>
        </subitems>
       </item>
       <item>
        <id>i2</id>
         <name>item2</name>
          <subitems>
           <name>subitem1</name>
           <name>subitem2</name>
          </subitems>
         </item>
        </items>";
    StringReader rr = new StringReader(sss);
    DataSet sdread = new DataSet();
    sdread.ReadXml(rr);
