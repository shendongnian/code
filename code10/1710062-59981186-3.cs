                var convertidor = new ValueConverter<DateTime, string>
                    (f => f.ATextoYYMMDD(), s => s.AFechaYYMMDD());    
                foreach (var tipoEntidad in constructor.Model
                    .GetEntityTypes().Where(t => typeof(IYourInterface).IsAssignableFrom(t.ClrType.BaseType))) {
                    constructor.Entity(tipoEntidad.Name)
                        .Property("YourPropertyName").HasConversion(convertidor);
                }
