    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Linq.Expressions;
    
    namespace ConsoleApplication1 {
    	public class Product1 {
    		public int Id { get; set; }
    		public string Name { get; set; }
    		public decimal Weight { get; set; }
    	}
    
    	public class Product2 {
    		public int Id { get; set; }
    		public string Name { get; set; }
    		public decimal Weight { get; set; }
    	}
    
    	class Program {
    		static void Main( string[] args ) {
    			// list of products typed as Product1
    			var lst1 = new List<Product1> {
    				new Product1{ Id = 1, Name = "One" },
    				new Product1{ Id = 15, Name = "Fifteen" },
    				new Product1{ Id = 9, Name = "Nine" }
    			};
    
    			// the expression for filtering products
    			// typed as Product1
    			Expression<Func<Product1, bool>> q1;
    			q1 = p => p.Id == 15;
    
    			// list of products typed as Product2
    			var lst2 = new List<Product2> {
    				new Product2{ Id = 1, Name = "One" },
    				new Product2{ Id = 15, Name = "Fifteen" },
    				new Product2{ Id = 9, Name = "Nine" }
    			};
    
    			// type of Product1
    			var tp1 = typeof( Product1 );
    			// property info of "Id" property from type Product1
    			var tp1Id = tp1.GetProperty( "Id", BindingFlags.Public | BindingFlags.Instance );
    			// delegate type for predicating for Product1
    			var tp1FuncBool = typeof( Func<,> ).MakeGenericType( tp1, typeof( bool ) );
    
    			// type of Product2
    			var tp2 = typeof( Product2 );
    			// property info of "Id" property from type Product2
    			var tp21Id = tp2.GetProperty( "Id", BindingFlags.Public | BindingFlags.Instance );
    			// delegate type for predicating for Product2
    			var tp2FuncBool = typeof( Func<,> ).MakeGenericType( tp2, typeof( bool ) );
    
    			// mapping object for types and type members
    			var cm1 = new CrossMapping {
    				TypeMapping = {
    					// Product1 -> Product2
    					{ tp1, tp2 },
    					// Func<Product1, bool> -> Func<Product2, bool>
    					{ tp1FuncBool, tp2FuncBool }
    				},
    				MemberMapping = {
    					// Product1.Id -> Product2.Id
    					{ tp1Id, tp21Id }
    				}
    			};
    
    			// mutate express from Product1's "enviroment" to Product2's "enviroment"
    			var cq1_2 = MutateExpression( q1, cm1 );
    
    			// compile lambda to delegate
    			var dlg1_2 = ((LambdaExpression)cq1_2).Compile();
    
    			// executing delegate
    			var rslt1_2 = lst2.Where( (Func<Product2, bool>)dlg1_2 ).ToList();
    
    			return;
    		}
    
    		class CrossMapping {
    			public IDictionary<Type, Type> TypeMapping { get; private set; }
    			public IDictionary<MemberInfo, MemberInfo> MemberMapping { get; private set; }
    
    			public CrossMapping() {
    				this.TypeMapping = new Dictionary<Type, Type>();
    				this.MemberMapping = new Dictionary<MemberInfo, MemberInfo>();
    			}
    		}
    		static Expression MutateExpression( Expression originalExpression, CrossMapping mapping ) {
    			var ret = MutateExpression(
    				originalExpression: originalExpression,
    				parameterExpressions: null,
    				mapping: mapping
    			);
    
    			return ret;
    		}
    		static Expression MutateExpression( Expression originalExpression, IList<ParameterExpression> parameterExpressions, CrossMapping mapping ) {
    			Expression ret;
    
    			if ( null == originalExpression ) {
    				ret = null;
    			}
    			else if ( originalExpression is LambdaExpression ) {
    				ret = MutateLambdaExpression( (LambdaExpression)originalExpression, parameterExpressions, mapping );
    			}
    			else if ( originalExpression is BinaryExpression ) {
    				ret = MutateBinaryExpression( (BinaryExpression)originalExpression, parameterExpressions, mapping );
    			}
    			else if ( originalExpression is ParameterExpression ) {
    				ret = MutateParameterExpression( (ParameterExpression)originalExpression, parameterExpressions, mapping );
    			}
    			else if ( originalExpression is MemberExpression ) {
    				ret = MutateMemberExpression( (MemberExpression)originalExpression, parameterExpressions, mapping );
    			}
    			else if ( originalExpression is ConstantExpression ) {
    				ret = MutateConstantExpression( (ConstantExpression)originalExpression, parameterExpressions, mapping );
    			}
    			else {
    				throw new NotImplementedException();
    			}
    
    			return ret;
    		}
    
    		static Type MutateType( Type originalType, IDictionary<Type, Type> typeMapping ) {
    			if ( null == originalType ) { return null; }
    
    			Type ret;
    			typeMapping.TryGetValue( originalType, out ret );
    			if ( null == ret ) { ret = originalType; }
    
    			return ret;
    		}
    		static MemberInfo MutateMember( MemberInfo originalMember, IDictionary<MemberInfo, MemberInfo> memberMapping ) {
    			if ( null == originalMember ) { return null; }
    
    			MemberInfo ret;
    			memberMapping.TryGetValue( originalMember, out ret );
    			if ( null == ret ) { ret = originalMember; }
    
    			return ret;
    		}
    		static LambdaExpression MutateLambdaExpression( LambdaExpression originalExpression, IList<ParameterExpression> parameterExpressions, CrossMapping mapping ) {
    			if ( null == originalExpression ) { return null; }
    
    			var newParameters = (from p in originalExpression.Parameters
    								 let np = MutateParameterExpression( p, parameterExpressions, mapping )
    								 select np).ToArray();
    
    			var newBody = MutateExpression( originalExpression.Body, newParameters, mapping );
    
    			var newType = MutateType( originalExpression.Type, mapping.TypeMapping );
    
    			var ret = Expression.Lambda(
    				delegateType: newType,
    				body: newBody,
    				name: originalExpression.Name,
    				tailCall: originalExpression.TailCall,
    				parameters: newParameters
    			);
    
    			return ret;
    		}
    		static BinaryExpression MutateBinaryExpression( BinaryExpression originalExpression, IList<ParameterExpression> parameterExpressions, CrossMapping mapping ) {
    			if ( null == originalExpression ) { return null; }
    
    			var newExprConversion = MutateExpression( originalExpression.Conversion, parameterExpressions, mapping );
    			var newExprLambdaConversion = (LambdaExpression)newExprConversion;
    			var newExprLeft = MutateExpression( originalExpression.Left, parameterExpressions, mapping );
    			var newExprRigth = MutateExpression( originalExpression.Right, parameterExpressions, mapping );
    			var newType = MutateType( originalExpression.Type, mapping.TypeMapping );
    			var newMember = MutateMember( originalExpression.Method, mapping.MemberMapping);
    			var newMethod = (MethodInfo)newMember;
    
    			var ret = Expression.MakeBinary(
    				binaryType: originalExpression.NodeType,
    				left: newExprLeft,
    				right: newExprRigth,
    				liftToNull: originalExpression.IsLiftedToNull,
    				method: newMethod,
    				conversion: newExprLambdaConversion
    			);
    
    			return ret;
    		}
    		static ParameterExpression MutateParameterExpression( ParameterExpression originalExpresion, IList<ParameterExpression> parameterExpressions, CrossMapping mapping ) {
    			if ( null == originalExpresion ) { return null; }
    
    			ParameterExpression ret = null;
    			if ( null != parameterExpressions ) {
    				ret = (from p in parameterExpressions
    					   where p.Name == originalExpresion.Name
    					   select p).FirstOrDefault();
    			}
    
    			if ( null == ret ) {
    				var newType = MutateType( originalExpresion.Type, mapping.TypeMapping );
    
    				ret = Expression.Parameter( newType, originalExpresion.Name );
    			}
    
    			return ret;
    		}
    		static MemberExpression MutateMemberExpression( MemberExpression originalExpression, IList<ParameterExpression> parameterExpressions, CrossMapping mapping ) {
    			if ( null == originalExpression ) { return null; }
    
    			var newExpression = MutateExpression( originalExpression.Expression, parameterExpressions, mapping );
    			var newMember = MutateMember( originalExpression.Member, mapping.MemberMapping );
    
    			var ret = Expression.MakeMemberAccess(
    				expression: newExpression,
    				member: newMember
    			);
    
    			return ret;
    		}
    		static ConstantExpression MutateConstantExpression( ConstantExpression originalExpression, IList<ParameterExpression> parameterExpressions, CrossMapping mapping ) {
    			if ( null == originalExpression ) { return null; }
    
    			var newType = MutateType( originalExpression.Type, mapping.TypeMapping );
    			var newValue = originalExpression.Value;
    
    			var ret = Expression.Constant(
    				value: newValue,
    				type: newType
    			);
    
    			return ret;
    		}
    	}
    }
