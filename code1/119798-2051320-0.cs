    public static bool TryGetAttribute<T>(MemberInfo memberInfo, out T customAttribute) where T: Attribute {
                    var attributes = memberInfo.GetCustomAttributes(typeof(T), false).FirstOrDefault();
                    if (attributes == null) {
                        customAttribute = null;
                        return false;
                    }
                    customAttribute = (T)attributes;
                    return true;
                }
