    using System.CodeDom;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    [Designer(typeof(MyControlDesigner))]
    public partial class MyControl : Control
    {
    }
    public class MyControlDesigner : ControlDesigner
    {
        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            var component = this.Component;
            var eventBindingService = (IEventBindingService)this.GetService(
                typeof(IEventBindingService));
            var componentChangeService = (IComponentChangeService)this.GetService(
                typeof(IComponentChangeService));
            var designerHostService = (IDesignerHost)GetService(typeof(IDesignerHost));
            var uiService = (IUIService)GetService(typeof(IUIService));
            var designerTransaction = (DesignerTransaction)null;
            try
            {
                designerTransaction = designerHostService.CreateTransaction();
                var e = TypeDescriptor.GetEvents(component)["Click"];
                if (e != null)
                {
                    var methodName = eventBindingService.CreateUniqueMethodName(component, e);
                    var eventProperty = eventBindingService.GetEventProperty(e);
                    if (eventProperty.GetValue(component) == null)
                    {
                        eventProperty.SetValue(component, methodName);
                        var code = this.GetService(typeof(CodeTypeDeclaration))
                            as CodeTypeDeclaration;
                        CodeMemberMethod method = null;
                        var member = code.Members.Cast<CodeTypeMember>()
                            .Where(x => x.Name == methodName).FirstOrDefault();
                        if (member != null)
                        {
                            method = (CodeMemberMethod)member;
                            method.Statements.Add(
                                new CodeSnippetStatement("MessageBox.Show(\"Hi!\");"));
                        }
                        componentChangeService.OnComponentChanged(component,
                            eventProperty, null, null);
                        eventBindingService.ShowCode(component, e);
                    }
                }
                designerTransaction.Commit();
            }
            catch (System.Exception ex)
            {
                if (designerTransaction != null)
                    designerTransaction.Cancel();
                uiService.ShowError(ex);
            }
        }
    }
