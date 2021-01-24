    public class ApplicationUser 
    {
        //other properties...
    
        [InverseProperty("UsuarioAsignado")]
        public virtual ICollection<UsuarioHasPermisoEnUsuario> UsuarioAsignados {get;set;}
    
        [InverseProperty("Usuario")]
        public virtual ICollection<UsuarioHasPermisoEnUsuario> Usuarios {get;set;}
    }
