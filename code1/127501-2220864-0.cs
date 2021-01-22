    interface ISkillState { ... }
    interface ISkill { ... }
    interface IForm
    {
        Collection<ISkill> skills { get; set; }
        Dictionary<ISkill,ISkillState> skillStates { get; set; }
    }
    class Character
    {
        private IForm actualForm;
        private Collection<IForm> currentForms;
        ...
    }
