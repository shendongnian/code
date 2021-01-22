    class InternalDbType {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        // Many more properties here...
    }
    class SimpleDTO {
        public string Name { get; set; }
        // Many more properties here...
    }
    class ComplexDTO : SimpleDTO {
        public string Date { get; set; }
    }
    static class InternalDbTypeExtensions {
        public static TDto ToDto<TDto>(this InternalDbType obj) where TDto : SimpleDTO, new() {
            var dto = new TDto {
                Name = obj.Name
            }
        }
    }
    
