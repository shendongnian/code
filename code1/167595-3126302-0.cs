    public abstract partial class CommonEntityBase {
        public abstract CommonDTOBase ToDto();
    }
    public partial class PersonEntity : CommonEntityBase {
        public override PersonDTO ToDto(){ return new PersonDTO(); }
    }
