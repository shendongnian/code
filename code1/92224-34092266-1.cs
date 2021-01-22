    protected override string Validate(string property) {
            Debug.WriteLine(property);
            if (property == nameof(YourProperty)) {
                if (_property > 5) {
                    return "_property out of range";
                }
            }
            return base.Validate(property);
        }
