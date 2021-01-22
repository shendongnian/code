    public abstract partial class CommonEntityBase {
        public abstract CommonDTOBase ToDto();
    }
    public partial class PersonEntity : CommonEntityBase {
        // changed PersonDTO to CommonDTOBase
        public override CommonDTOBase ToDto(){ return new PersonDTO(); }
    }
