        public class BinaryBytesModelBinder: IModelBinder
        {
            internal class LegacyAssemblySerializationBinder : SerializationBinder 
            {
                public override Type BindToType(string assemblyName, string typeName) {
                    var typeToDeserialize = Assembly.GetEntryAssembly()
                        .GetType(typeName);   // we use the same typename by convention
                    return typeToDeserialize;
                }
            }
            public Task BindModelAsync(ModelBindingContext bindingContext)
            {
                if (bindingContext == null) { throw new ArgumentNullException(nameof(bindingContext)); }
                var modelName = bindingContext.BinderModelName?? "LegacyBinaryData";
                var req = bindingContext.HttpContext.Request;
                var raw= req.Body;
                if(raw == null){ 
                    bindingContext.ModelState.AddModelError(modelName,"invalid request body stream");
                    return Task.CompletedTask;
                }
                var formatter= new BinaryFormatter();
                formatter.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
                formatter.Binder = new LegacyAssemblySerializationBinder();
                var o = formatter.Deserialize(raw);
                bindingContext.Result = ModelBindingResult.Success(o);
                return Task.CompletedTask;
            }
        }
