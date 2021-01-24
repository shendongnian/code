    var yourXML = @"<ProjectDetails>
           <Product>
               <ProductId>1</ProductId>
               <ProductName>Product 1</ProductName>
           </Product>
           <Owner>
               <OwnerId>1</OwnerId>
               <OwnerName>Owner 1</OwnerName>
           </Owner>
           <Master>
               <MasterId>1</MasterId>
               <MasterName>Master 1</MasterName>
           </Master>
        </ProjectDetails>"    
    XmlSerializer serializer = new XmlSerializer(typeof(ProjectDetails));
    using (TextReader reader = new StringReader(yourXML)) {
        ProjectDetails result = (ProjectDetails) serializer.Deserialize(reader);
    }
