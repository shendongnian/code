    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    namespace App.Abstractions
    {
        [Serializable]
        abstract public class AEntity
        {
            public int Id { get; set; }
    
            public IEnumerable<ValidationResult> Validate()
            {
                var vResults = new List<ValidationResult>();
    
                var vc = new ValidationContext(
                    instance: this,
                    serviceProvider: null,
                    items: null);
    
                var isValid = Validator.TryValidateObject(
                    instance: vc.ObjectInstance,
                    validationContext: vc,
                    validationResults: vResults,
                    validateAllProperties: true);
    
                /*
                if (true)
                {
                    yield return new ValidationResult("Custom Validation","A Property Name string (optional)");
                }
                */
    
                if (!isValid)
                {
                    foreach (var validationResult in vResults)
                    {
                        yield return validationResult;
                    }
                }
    
                yield break;
            }
    
    
        }
    }
