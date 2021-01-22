    	public static class ControlExtensions {
		/// <summary>Databinding with strongly typed object names</summary>
		/// <param name="control">The Control you are binding to</param>
		/// <param name="controlProperty">The property on the control you are binding to</param>
		/// <param name="dataSource">The object you are binding to</param>
		/// <param name="dataSourceProperty">The property on the object you are binding to</param>
		public static Binding Bind<TControl, TDataSourceItem>(this TControl control, Expression<Func<TControl, object>> controlProperty, object dataSource, Expression<Func<TDataSourceItem, object>> dataSourceProperty)
		where TControl :Control {
			return control.DataBindings.Add(PropertyName.For(controlProperty), dataSource, PropertyName.For(dataSourceProperty));
		}
		public static Binding Bind<TControl, TDataSourceItem>(this TControl control, Expression<Func<TControl, object>> controlProperty, object dataSource, Expression<Func<TDataSourceItem, object>> dataSourceProperty, bool formattingEnabled = false)
		where TControl :Control {
			return control.DataBindings.Add(PropertyName.For(controlProperty), dataSource, PropertyName.For(dataSourceProperty), formattingEnabled);
		}
		public static Binding Bind<TControl, TDataSourceItem>(this TControl control, Expression<Func<TControl, object>> controlProperty, object dataSource, Expression<Func<TDataSourceItem, object>> dataSourceProperty, bool formattingEnabled, DataSourceUpdateMode updateMode)
		where TControl :Control {
			return control.DataBindings.Add(PropertyName.For(controlProperty), dataSource, PropertyName.For(dataSourceProperty), formattingEnabled, updateMode);
		}
		public static Binding Bind<TControl, TDataSourceItem>(this TControl control, Expression<Func<TControl, object>> controlProperty, object dataSource, Expression<Func<TDataSourceItem, object>> dataSourceProperty, bool formattingEnabled, DataSourceUpdateMode updateMode, object nullValue)
		where TControl :Control {
			return control.DataBindings.Add(PropertyName.For(controlProperty), dataSource, PropertyName.For(dataSourceProperty), formattingEnabled, updateMode, nullValue);
		}
		public static Binding Bind<TControl, TDataSourceItem>(this TControl control, Expression<Func<TControl, object>> controlProperty, object dataSource, Expression<Func<TDataSourceItem, object>> dataSourceProperty, bool formattingEnabled, DataSourceUpdateMode updateMode, object nullValue, string formatString)
		where TControl :Control {
			return control.DataBindings.Add(PropertyName.For(controlProperty), dataSource, PropertyName.For(dataSourceProperty), formattingEnabled, updateMode, nullValue, formatString);
		}
		public static Binding Bind<TControl, TDataSourceItem>(this TControl control, Expression<Func<TControl, object>> controlProperty, object dataSource, Expression<Func<TDataSourceItem, object>> dataSourceProperty, bool formattingEnabled, DataSourceUpdateMode updateMode, object nullValue, string formatString, IFormatProvider formatInfo)
		where TControl :Control {
			return control.DataBindings.Add(PropertyName.For(controlProperty), dataSource, PropertyName.For(dataSourceProperty), formattingEnabled, updateMode, nullValue, formatString, formatInfo);
		}
		public static class PropertyName {
			public static string For<T>(Expression<Func<T, object>> property) {
				var member = property.Body as MemberExpression;
				if(null == member) {
					var unary = property.Body as UnaryExpression;
					if(null != unary) member = unary.Operand as MemberExpression;
				}
				return null != member ? member.Member.Name : string.Empty;
			}
		}
	}
