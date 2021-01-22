	public class Registration<T> where T : class {
		public string Name { get; set; }
		public Func<T> CreateLambda { get; set; }
		public override bool Equals(object obj) {
			var other = obj as Registration<T>;
			if(other == null) {
				return false;
			}
			return this.Name == other.Name && this.CreateLambda == other.CreateLambda;
		}
		public override int GetHashCode() {
			int hash = 17;
			hash = hash * 23 + (Name != null ? Name.GetHashCode() : string.Empty.GetHashCode());
			hash = hash * 23 + (CreateLambda != null ? CreateLambda.GetHashCode() : 0);
			return hash;
		}
    
    
	}
	public static class UnityExtensions {
		public static IEnumerable<Registration<T>> ResolveWithName<T>(this UnityContainer container) where T : class {
			return container.Registrations
			  .Where(r => r.RegisteredType == typeof(T))
			  .Select(r => new Registration<T> { Name = r.Name, CreateLambda = ()=>container.Resolve<T>(r.Name) });
		}
	}
     public class CalculationRuleProcessFactory : ICalculationRuleProcessFactory
      {
        private readonly IBatchStatusWriter _batchStatusWriter;
        private readonly IEnumerable<Registration<ICalculationRuleProcess>> _Registrations;
    
        public CalculationRuleProcessFactory(
          IEnumerable<Registration<ICalculationRuleProcess>> registrations,
          IBatchStatusWriter batchStatusWriter )
        {
          _batchStatusWriter = batchStatusWriter;
          _Registrations= registrations;
        }
    
        public ICalculationRuleProcess Create( DistributionRule distributionRule )
        {
          _batchStatusWriter.WriteBatchStatusMessage( 
            string.Format( "Applying {0} Rule", distributionRule.Descr ) );
          //will crash if registration is not present
          return _Registrations
            .FirstOrDefault(r=>r.Name == distributionRule.Id.ToString())
            .CreateLambda();
        }
      }
    //Registrations
    var registrations = container.ResolveWithName<ICalculationRuleProcess>(container);
    container.RegisterInstance<IEnumerable<Registration<ICalculationRuleProcess>>>(registrations);
