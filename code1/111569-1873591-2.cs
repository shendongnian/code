    public abstract class ModelStateValidator
    {
      private Controller controller;
      protected Controller Controller {
        get { return controller; }
      }
      public abstract ActionResult GetResult();
      #region initialization
      static ModelStateValidator() {
        creators[ControllerState.InvalidModel] = () => new InvalidModelState();
        creators[ControllerState.ValidModel] = () => new ValidModelState();
      }
      #endregion
      #region Creation
      private static Dictionary<ControllerState, Func<ModelStateValidator>> creators = new Dictionary<ControllerState, Func<ModelStateValidator>>();
      public static ModelStateValidator Create(Controller controller) {
        return creators[GetControllerState(controller)]();
      }
      private static ControllerState GetControllerState(Controller c) {
        return new ControllerState(c);
      }
      internal class ControllerState
      {
        private readonly Controller controller;
        private readonly bool isModelValid;
        public ControllerState(Controller controller)
          : this(controller.ModelState.IsValid) {
          this.controller = controller;
        }
        private ControllerState(bool isModelValid) {
          this.isModelValid = isModelValid;
        }
        public static ControllerState ValidModel {
          get { return new ControllerState(true); }
        }
        public static ControllerState InvalidModel {
          get { return new ControllerState(false); }
        }
        public override bool Equals(object obj) {
          if (obj == null || GetType() != obj.GetType())  //I can show you how to remove this one if you are interested ;)
          {
            return false;
          }
          return this.isModelValid == ((ControllerState)obj).isModelValid;
        }
        public override int GetHashCode() {
          return this.isModelValid.GetHashCode();
        }
      }
      #endregion
    }
    class InvalidModelState : ModelStateValidator
    {
      public override ActionResult GetResult() {
        return Controller.View(organisationInput.RebuildInput<Organisation, OrganisationInput>());
      }
    }
    class ValidModelState : ModelStateValidator
    {
      public override ActionResult GetResult() {
        return this.Controller.RedirectToAction("Index");
      }
    }
