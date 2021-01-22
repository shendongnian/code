    public class CustomModelBinder :  DefaultModelBinder {
    protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor) {
        if(propertyDescriptor.Name == "PropertyWithCharactersIneedToReplace") {
            MethodThatReplacesCharacters();
            return;
        }
        base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
    }
