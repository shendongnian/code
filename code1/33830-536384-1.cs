    public interface ICloneable<T> : ICloneable {
        new T Clone();
    }
    
    public abstract class CloneableBase<T> : ICloneable<T> where T : CloneableBase<T> {
        public abstract T Clone();
        object ICloneable.Clone() { return this.Clone(); }
    }
    
    public abstract class CloneableExBase<T> : CloneableBase<T> where T : CloneableExBase<T> {
        protected abstract T CreateClone();
        protected abstract void FillClone( T clone );
        public override T Clone() {
            T clone = this.CreateClone();
            if ( object.ReferenceEquals( clone, null ) ) { throw new NullReferenceException( "Clone was not created." ); }
            return clone
        }
    }
    
    public abstract class PersonBase<T> : CloneableExBase<T> where T : PersonBase<T> {
        public string Name { get; set; }
    
        protected override void FillClone( T clone ) {
            clone.Name = this.Name;
        }
    }
    
    public sealed class Person : PersonBase<Person> {
        protected override Person CreateClone() { return new Person(); }
    }
    
    public abstract class EmployeeBase<T> : PersonBase<T> where T : EmployeeBase<T> {
        public string Department { get; set; }
    
        protected override void FillClone( T clone ) {
            base.FillClone( clone );
            clone.Department = this.Department;
        }
    }
    
    public sealed class Employee : EmployeeBase<Employee> {
        protected override Employee CreateClone() { return new Employee(); }
    }
