    public List<ImageData> GetDocuments( User user, DocumentSearchCriterion criterion )
    {
        List<ImageData> documents = new DocumentRepository().GetDocuments( user, criterion );
    
        // Temporary test to see if we can serialize the data. This is only for debugging
        // purposes and needs to be removed from production code.
        DataContractSerializer serializer = new DataContractSerializer( documents.GetType() );
        using( FileStream stream = new FileStream( "SerializerOutput.xml", FileMode.Create ) )
        {
            // This line will give an exception with useful details while debugging.
            serializer.WriteObject( stream, documents );
        }
        
        return documents;
    }
