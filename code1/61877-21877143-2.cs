		#region 数据克隆
		/// <summary>
		/// 依据不同类型所存储的克隆句柄集合
		/// </summary>
		private static readonly Dictionary<Type, Func<object, object>> CloneHandlers = new Dictionary<Type, Func<object, object>>();
		/// <summary>
		/// 根据指定的实例,克隆一份新的实例
		/// </summary>
		/// <param name="source">待克隆的实例</param>
		/// <returns>被克隆的新的实例</returns>
		public static object CloneInstance(object source)
		{
			if (source == null)
			{
				return null;
			}
			Func<object, object> handler = TryGetOrAdd(CloneHandlers, source.GetType(), CreateCloneHandler);
			return handler(source);
		}
		/// <summary>
		/// 根据指定的类型,创建对应的克隆句柄
		/// </summary>
		/// <param name="type">数据类型</param>
		/// <returns>数据克隆句柄</returns>
		private static Func<object, object> CreateCloneHandler(Type type)
		{
			return Delegate.CreateDelegate(typeof(Func<object, object>), new Func<object, object>(CloneAs<object>).Method.GetGenericMethodDefinition().MakeGenericMethod(type)) as Func<object, object>;
		}
		/// <summary>
		/// 克隆一个类
		/// </summary>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		private static object CloneAs<TValue>(object value)
		{
			return Copier<TValue>.Clone((TValue)value);
		}
		/// <summary>
		/// 生成一份指定数据的克隆体
		/// </summary>
		/// <typeparam name="TValue">数据的类型</typeparam>
		/// <param name="value">需要克隆的值</param>
		/// <returns>克隆后的数据</returns>
		public static TValue Clone<TValue>(TValue value)
		{
			if (value == null)
			{
				return value;
			}
			return Copier<TValue>.Clone(value);
		}
		/// <summary>
		/// 辅助类,完成数据克隆
		/// </summary>
		/// <typeparam name="TValue">数据类型</typeparam>
		private static class Copier<TValue>
		{
			/// <summary>
			/// 用于克隆的句柄
			/// </summary>
			internal static readonly Func<TValue, TValue> Clone;
			/// <summary>
			/// 初始化
			/// </summary>
			static Copier()
			{
				MethodFactory<Func<TValue, TValue>> method = MethodFactory.Create<Func<TValue, TValue>>();
				Type type = typeof(TValue);
				if (type == typeof(object))
				{
					method.LoadArg(0).Return();
					return;
				}
				switch (Type.GetTypeCode(type))
				{
					case TypeCode.Object:
						if (type.IsClass)
						{
							method.LoadArg(0).Call(Reflector.GetMethod(typeof(object), "MemberwiseClone")).Cast(typeof(object), typeof(TValue)).Return();
						}
						else
						{
							method.LoadArg(0).Return();
						}
						break;
					default:
						method.LoadArg(0).Return();
						break;
				}
				Clone = method.Delegation;
			}
		}
		#endregion
