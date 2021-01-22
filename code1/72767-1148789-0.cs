    public partial MyDataContext
    {
            [Function(Name="dbo.spGetNote")]        
            public ISingleResult<Note> spGetNote([Parameter(DbType="Int")]...
    }
    
    public class Note...
