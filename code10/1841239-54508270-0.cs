        internal void RegisterIntentHandlers(IntentManager registry)
        {
            RegisterIntentHandlers(this.GetType(), registry);
        }
        internal void RegisterIntentHandlers(Type klass, IntentManager registry)
        {
            foreach (System.Reflection.MethodInfo m in klass.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance))
            {
                foreach (Attribute attribute in m.GetCustomAttributes())
                {
                    if (attribute is IntentHandler)
                    {
                        if (m.GetParameters().Count() == 1)
                        {
                            ParameterInfo p = m.GetParameters()[0];
                            Type paramClass = p.ParameterType;
                            if (paramClass.IsAssignableFrom(typeof(Intent)))
                            {
                                object consumerKey = this.GetType().FullName + "#" + m.Name;
                                Action<Intent> intentConsumer = (Action<Intent>)m.CreateDelegate(typeof(Action<Intent>), this);
                                registry.RegisterForIntent<Intent>(paramClass, consumerKey, intentConsumer);
                                if (!registration.ContainsKey(paramClass))
                                    registration[paramClass].Add(consumerKey);
                            }
                        }
                    }
                }
            }
        }
