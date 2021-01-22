class User {
    [Required]
    public string Name{get;set;}
    
    [Email][Required]
    public string Email {get;set;}
}
