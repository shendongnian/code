    [AttributeUsage(AttributeTargets.Property, AllowMultiple =false)]
    public class StepAttribute: Attribute
    {
        public StepEnum Step { get; set; }
    }
    public interface IWizardStep
    {
    }
    public interface IWizardTransaction
    {
    }
    public enum StepEnum
    {
        Previous,
        CurrentStep
    }
    public class WizardStep: IWizardStep
    {
        public string StepName { get; set; }
        public override string ToString()
        {
            return StepName;
        }
    }
    public class Wizard : IWizardTransaction
    {
        [Step(Step = StepEnum.Previous)]
        public WizardStep ClientDetails => new WizardStep() { StepName = "ClientDetails" };
        [Step(Step = StepEnum.CurrentStep)]
        public WizardStep ClientQuestions => new WizardStep() { StepName = "ClientQuestions" };
    }
