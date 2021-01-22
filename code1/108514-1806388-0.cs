    Concept conceptToUpdate = new Concept() {
          Id = 1 , 
          ConceptType = new ConceptType {Id = OriginalFKValue}
    };
    ConceptType conceptType = new ConceptType() { Id = 5 };
    db.AttachTo("Concept", conceptToUpdate); 
    db.AttachTo("ConceptType", conceptType);
    conceptToUpdate.ConceptType = conceptType;
    db.SaveChanges();
