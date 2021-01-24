    public class ClassA : AggregateRoot
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int ClassBId { get; private set; }
        private ClassA() { }
        
        private ClassA(CreateClassACommand command) : base(command.Id)
        {
            this.Name = command.Name;
            this.ClassBId = command.ClassBId;
            // You can create events and store them later on as auditing or
            // have others subscribe this event. 
            AddEvent(new ClassACreated
            {
                // ...
            });
        }
        public static ClassA CreateNew(CreateClassACommand command,
            IValidator<CreateClassACommand> validator)
        {
            // You can have validations here too, with help of FluentValidation
            // library
            validator.ValidateAndThrow(command);
            return new ClassA(command);
        }
        public void UpdateDetails(UpdateClassADetailsCommand command,
            IValidator<UpdateClassADetailsCommand> validator)
        {
            validator.ValidateAndThrow(command);
            this.Name = command.Name;
            this.ClassBId = command.SelectedClassBId;
            AddEvent(new ClassADetailsUpdated 
            {
                // ...
            });
        }
    }
