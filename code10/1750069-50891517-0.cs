    Public Class AuditBase
    {
    //Adapt your requirements, the propertys are exists in db
    Public datetime creationdate { get; set; }
    Public datetime modificationdate { get; set; }
    Public string creationuser { get; set; }
    Public string modificationuser { get; set; }
    }
    Public class ModelBBDD : AuditBase
    { }
