    using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Text;
	using NUnit.Framework;
	using NUnit.Framework.Constraints;
	namespace Tests
	{
		public class ContentsEqualConstraint : Constraint
		{
			private readonly object expected;
			private Constraint failedEquality;
			private string expectedDescription;
			private string actualDescription;
			private readonly Stack<string> typePath = new Stack<string>();
			private string typePathExpanded;
			private readonly HashSet<string> _ignoredNames = new HashSet<string>();
			private readonly HashSet<Type> _ignoredTypes = new HashSet<Type>();
			private readonly LinkedList<Type> _ignoredInterfaces = new LinkedList<Type>();
			private readonly LinkedList<string> _ignoredSuffixes = new LinkedList<string>();
			private readonly IDictionary<Type, Func<object, object, bool>> _predicates = new Dictionary<Type, Func<object, object, bool>>();
			private bool _withoutSort;
			private int _maxRecursion = int.MaxValue;
			
			private readonly HashSet<VisitedComparison> _visitedObjects = new HashSet<VisitedComparison>();
			private static readonly HashSet<string> _globallyIgnoredNames = new HashSet<string>();
			private static readonly HashSet<Type> _globallyIgnoredTypes = new HashSet<Type>();
			private static readonly LinkedList<Type> _globallyIgnoredInterfaces = new LinkedList<Type>();
			private static object _regionalTolerance;
			public ContentsEqualConstraint(object expectedValue)
			{
				expected = expectedValue;
			}
			public ContentsEqualConstraint Comparing<T>(Func<T, T, bool> predicate)
			{
				Type t = typeof (T);
				if (predicate == null)
				{
					_predicates.Remove(t);
				}
				else
				{
					_predicates[t] = (x, y) => predicate((T) x, (T) y);
				}
				return this;
			}
			public ContentsEqualConstraint Ignoring(string fieldName)
			{
				_ignoredNames.Add(fieldName);
				return this;
			}
			public ContentsEqualConstraint Ignoring(Type fieldType)
			{
				if (fieldType.IsInterface)
				{
					_ignoredInterfaces.AddFirst(fieldType);
				}
				else
				{
					_ignoredTypes.Add(fieldType);
				}
				return this;
			}
			public ContentsEqualConstraint IgnoringSuffix(string suffix)
			{
				if (string.IsNullOrEmpty(suffix))
				{
					throw new ArgumentNullException("suffix");
				}
				_ignoredSuffixes.AddLast(suffix);
				return this;
			}
			public ContentsEqualConstraint WithoutSort()
			{
				_withoutSort = true;
				return this;
			}
			public ContentsEqualConstraint RecursingOnly(int levels)
			{
				_maxRecursion = levels;
				return this;
			}
			public static void GlobalIgnore(string fieldName)
			{
				_globallyIgnoredNames.Add(fieldName);
			}
			public static void GlobalIgnore(Type fieldType)
			{
				if (fieldType.IsInterface)
				{
					_globallyIgnoredInterfaces.AddFirst(fieldType);
				}
				else
				{
					_globallyIgnoredTypes.Add(fieldType);
				}
			}
			public static IDisposable RegionalIgnore(string fieldName)
			{
				return new RegionalIgnoreTracker(fieldName);
			}
			public static IDisposable RegionalIgnore(Type fieldType)
			{
				return new RegionalIgnoreTracker(fieldType);
			}
			public static IDisposable RegionalWithin(object tolerance)
			{
				return new RegionalWithinTracker(tolerance);
			}
			public override bool Matches(object actualValue)
			{
				typePathExpanded = null;
				actual = actualValue;
				return Matches(expected, actualValue);
			}
			private bool Matches(object expectedValue, object actualValue)
			{
				bool matches = true;
				if (!MatchesNull(expectedValue, actualValue, ref matches))
				{
					return matches;
				}
				// DatesEqualConstraint supports tolerance in dates but works as equal constraint for everything else
				Constraint eq = new DatesEqualConstraint(expectedValue).Within(tolerance ?? _regionalTolerance);
				if (eq.Matches(actualValue))
				{
					return true;
				}
				if (MatchesVisited(expectedValue, actualValue, ref matches))
				{
					if (MatchesDictionary(expectedValue, actualValue, ref matches) &&
						MatchesList(expectedValue, actualValue, ref matches) &&
						MatchesType(expectedValue, actualValue, ref matches) &&
						MatchesPredicate(expectedValue, actualValue, ref matches))
					{
						MatchesFields(expectedValue, actualValue, eq, ref matches);
					}
				}
				return matches;
			}
			private bool MatchesNull(object expectedValue, object actualValue, ref bool matches)
			{
				if (IsNullEquivalent(expectedValue))
				{
					expectedValue = null;
				}
				if (IsNullEquivalent(actualValue))
				{
					actualValue = null;
				}
				if (expectedValue == null && actualValue == null)
				{
					matches = true;
					return false;
				}
				if (expectedValue == null)
				{
					expectedDescription = "null";
					actualDescription = "NOT null";
					matches = Failure;
					return false;
				}
				if (actualValue == null)
				{
					expectedDescription = "not null";
					actualDescription = "null";
					matches = Failure;
					return false;
				}
				return true;
			}
			
			private bool MatchesType(object expectedValue, object actualValue, ref bool matches)
			{
				Type expectedType = expectedValue.GetType();
				Type actualType = actualValue.GetType();
				if (expectedType != actualType)
				{
					try
					{
						Convert.ChangeType(actualValue, expectedType);
					}
					catch(InvalidCastException)				
					{
						expectedDescription = expectedType.FullName;
						actualDescription = actualType.FullName;
						matches = Failure;
						return false;
					}
					
				}
				return true;
			}
			private bool MatchesPredicate(object expectedValue, object actualValue, ref bool matches)
			{
				Type t = expectedValue.GetType();
				Func<object, object, bool> predicate;
				if (_predicates.TryGetValue(t, out predicate))
				{
					matches = predicate(expectedValue, actualValue);
					return false;
				}
				return true;
			}
			private bool MatchesVisited(object expectedValue, object actualValue, ref bool matches)
			{
				var c = new VisitedComparison(expectedValue, actualValue);
				if (_visitedObjects.Contains(c))
				{
					matches = true;
					return false;
				}
				_visitedObjects.Add(c);
				return true;
			}
			private bool MatchesDictionary(object expectedValue, object actualValue, ref bool matches)
			{
				if (expectedValue is IDictionary && actualValue is IDictionary)
				{
					var expectedDictionary = (IDictionary)expectedValue;
					var actualDictionary = (IDictionary)actualValue;
					if (expectedDictionary.Count != actualDictionary.Count)
					{
						expectedDescription = expectedDictionary.Count + " item dictionary";
						actualDescription = actualDictionary.Count + " item dictionary";
						matches = Failure;
						return false;
					}
					foreach (DictionaryEntry expectedEntry in expectedDictionary)
					{
						if (!actualDictionary.Contains(expectedEntry.Key))
						{
							expectedDescription = expectedEntry.Key + " exists";
							actualDescription = expectedEntry.Key + " does not exist";
							matches = Failure;
							return false;
						}
						if (CanRecurseFurther)
						{
							typePath.Push(expectedEntry.Key.ToString());
							if (!Matches(expectedEntry.Value, actualDictionary[expectedEntry.Key]))
							{
								matches = Failure;
								return false;
							}
							typePath.Pop();
						}
					}
					matches = true;
					return false;
				}
				return true;
			}
			private bool MatchesList(object expectedValue, object actualValue, ref bool matches)
			{
				if (!(expectedValue is IList && actualValue is IList))
				{
					return true;
				}
				var expectedList = (IList) expectedValue;
				var actualList = (IList) actualValue;
				if (!Matches(expectedList.Count, actualList.Count))
				{
					matches = false;
				}
				else
				{
					if (CanRecurseFurther)
					{
						int max = expectedList.Count;
						if (max != 0 && !_withoutSort)
						{
							SafeSort(expectedList);
							SafeSort(actualList);
						}
						for (int i = 0; i < max; i++)
						{
							typePath.Push(i.ToString());
							if (!Matches(expectedList[i], actualList[i]))
							{
								matches = false;
								return false;
							}
							typePath.Pop();
						}
					}
					matches = true;
				}
				return false;
			}
			private void MatchesFields(object expectedValue, object actualValue, Constraint equalConstraint, ref bool matches)
			{
				Type expectedType = expectedValue.GetType();
				FieldInfo[] fields = expectedType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
				// should have passed the EqualConstraint check
				if (expectedType.IsPrimitive ||
					expectedType == typeof(string) ||
					expectedType == typeof(Guid) ||
					fields.Length == 0)
				{
					failedEquality = equalConstraint;
					matches = Failure;
					return;
				}
				if (expectedType == typeof(DateTime))
				{
					var expectedDate = (DateTime)expectedValue;
					var actualDate = (DateTime)actualValue;
					if (Math.Abs((expectedDate - actualDate).TotalSeconds) > 3.0)
					{
						failedEquality = equalConstraint;
						matches = Failure;
						return;
					}
					matches = true;
					return;
				}
				if (CanRecurseFurther)
				{
					while(true)
					{
						foreach (FieldInfo field in fields)
						{
							if (!Ignore(field))
							{
								typePath.Push(field.Name);
								if (!Matches(GetValue(field, expectedValue), GetValue(field, actualValue)))
								{
									matches = Failure;
									return;
								}
								typePath.Pop();
							}
						}
						expectedType = expectedType.BaseType;
						if (expectedType == null)
						{
							break;
						}
						fields = expectedType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
					}
				}
				matches = true;
				return;
			}
			private bool Ignore(FieldInfo field)
			{
				if (_ignoredNames.Contains(field.Name) ||
					_ignoredTypes.Contains(field.FieldType) ||
					_globallyIgnoredNames.Contains(field.Name) ||
					_globallyIgnoredTypes.Contains(field.FieldType) ||
					field.GetCustomAttributes(typeof (IgnoreContentsAttribute), false).Length != 0)
				{
					return true;
				}
				
				foreach(string ignoreSuffix in _ignoredSuffixes)
				{
					if (field.Name.EndsWith(ignoreSuffix))
					{
						return true;
					}
				}
				foreach (Type ignoredInterface in _ignoredInterfaces)
				{
					if (ignoredInterface.IsAssignableFrom(field.FieldType))
					{
						return true;
					}
				}
				return false;
			}
			
			private static bool Failure
			{
				get
				{
					return false;
				}
			}
			private static bool IsNullEquivalent(object value)
			{
				return value == null ||
						value == DBNull.Value ||
					   (value is int && (int) value == int.MinValue) ||
					   (value is double && (double) value == double.MinValue) ||
					   (value is DateTime && (DateTime) value == DateTime.MinValue) ||
					   (value is Guid && (Guid) value == Guid.Empty) ||
					   (value is IList && ((IList)value).Count == 0);
			}
			private static object GetValue(FieldInfo field, object source)
			{
				try
				{
					return field.GetValue(source);
				}
				catch(Exception ex)
				{
					return ex;
				}
			}
			public override void WriteMessageTo(MessageWriter writer)
			{
				if (TypePath.Length != 0)
				{
					writer.WriteLine("Failure on " + TypePath);
				}
				if (failedEquality != null)
				{
					failedEquality.WriteMessageTo(writer);
				}
				else
				{
					base.WriteMessageTo(writer);
				}
			}
			public override void WriteDescriptionTo(MessageWriter writer)
			{
				writer.Write(expectedDescription);
			}
			public override void WriteActualValueTo(MessageWriter writer)
			{
				writer.Write(actualDescription);
			}
			private string TypePath
			{
				get
				{
					if (typePathExpanded == null)
					{
						string[] p = typePath.ToArray();
						Array.Reverse(p);
						var text = new StringBuilder(128);
						bool isFirst = true;
						foreach(string part in p)
						{
							if (isFirst)
							{
								text.Append(part);
								isFirst = false;
							}
							else
							{
								int i;
								if (int.TryParse(part, out i))
								{
									text.Append("[" + part + "]");
								}
								else
								{
									text.Append("." + part);
								}
							}
						}
						typePathExpanded = text.ToString();
					}
					return typePathExpanded;
				}
			}
			private bool CanRecurseFurther
			{
				get
				{
					return typePath.Count < _maxRecursion;
				}
			}
			private static bool SafeSort(IList list)
			{
				if (list == null)
				{
					return false;
				}
				if (list.Count < 2)
				{
					return true;
				}
				try
				{
					object first = FirstNonNull(list) as IComparable;
					if (first == null)
					{
						return false;
					}
					if (list is Array)
					{
						Array.Sort((Array)list);
						return true;
					}
					return CallIfExists(list, "Sort");
				}
				catch
				{
					return false;
				}
			}
			private static object FirstNonNull(IEnumerable enumerable)
			{
				if (enumerable == null)
				{
					throw new ArgumentNullException("enumerable");
				}
				foreach (object item in enumerable)
				{
					if (item != null)
					{
						return item;
					}
				}
				return null;
			}
			private static bool CallIfExists(object instance, string method)
			{
				if (instance == null)
				{
					throw new ArgumentNullException("instance");
				}
				if (String.IsNullOrEmpty(method))
				{
					throw new ArgumentNullException("method");
				}
				Type target = instance.GetType();
				MethodInfo m = target.GetMethod(method, new Type[0]);
				if (m != null)
				{
					m.Invoke(instance, null);
					return true;
				}
				return false;
			}
			#region VisitedComparison Helper
			private class VisitedComparison
			{
				private readonly object _expected;
				private readonly object _actual;
				public VisitedComparison(object expected, object actual)
				{
					_expected = expected;
					_actual = actual;
				}
				public override int GetHashCode()
				{
					return GetHashCode(_expected) ^ GetHashCode(_actual);
				}
				private static int GetHashCode(object o)
				{
					if (o == null)
					{
						return 0;
					}
					return o.GetHashCode();
				}
				public override bool Equals(object obj)
				{
					if (obj == null)
					{
						return false;
					}
					if (obj.GetType() != typeof(VisitedComparison))
					{
						return false;
					}
					var other = (VisitedComparison) obj;
					return _expected == other._expected &&
						   _actual == other._actual;
				}
			}
			#endregion
			#region RegionalIgnoreTracker Helper
			private class RegionalIgnoreTracker : IDisposable
			{
				private readonly string _fieldName;
				private readonly Type _fieldType;
				public RegionalIgnoreTracker(string fieldName)
				{
					if (!_globallyIgnoredNames.Add(fieldName))
					{
						_globallyIgnoredNames.Add(fieldName);
						_fieldName = fieldName;
					}
				}
				public RegionalIgnoreTracker(Type fieldType)
				{
					if (!_globallyIgnoredTypes.Add(fieldType))
					{
						_globallyIgnoredTypes.Add(fieldType);
						_fieldType = fieldType;
					}
				}
				public void Dispose()
				{
					if (_fieldName != null)
					{
						_globallyIgnoredNames.Remove(_fieldName);
					}
					if (_fieldType != null)
					{
						_globallyIgnoredTypes.Remove(_fieldType);
					}
				}
			}
			#endregion
			#region RegionalWithinTracker Helper
			private class RegionalWithinTracker : IDisposable
			{
				public RegionalWithinTracker(object tolerance)
				{
					_regionalTolerance = tolerance;
				}
				public void Dispose()
				{
					_regionalTolerance = null;
				}
			}
			#endregion
			#region IgnoreContentsAttribute
			[AttributeUsage(AttributeTargets.Field)]
			public sealed class IgnoreContentsAttribute : Attribute
			{
			}
			#endregion
		}
		public class DatesEqualConstraint : EqualConstraint
		{
			private readonly object _expected;
			public DatesEqualConstraint(object expectedValue) : base(expectedValue)
			{
				_expected = expectedValue;
			}
			public override bool Matches(object actualValue)
			{
				if (tolerance != null && tolerance is TimeSpan)
				{
					if (_expected is DateTime && actualValue is DateTime)
					{
						var expectedDate = (DateTime) _expected;
						var actualDate = (DateTime) actualValue;
						var toleranceSpan = (TimeSpan) tolerance;
						if ((actualDate - expectedDate).Duration() <= toleranceSpan)
						{
							return true;
						}
					}
					tolerance = null;
				}
				return base.Matches(actualValue);
			}
		}
	}
