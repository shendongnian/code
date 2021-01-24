    public static class ServiceProviderExtension {
        /// <summary>
        /// Get service of type <typeparamref name="TService"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        public static TService GetService<TService>(this IServiceProvider provider) {
            return (TService)provider.GetService(typeof(TService));
        }
        /// <summary>
        /// Get an enumeration of services of type <paramref name="serviceType"/> from the <see cref="IServiceProvider"/>
        /// </summary>
        public static IEnumerable<object> GetServices(this IServiceProvider provider, Type serviceType) {
            var genericEnumerable = typeof(IEnumerable<>).MakeGenericType(serviceType);
            return (IEnumerable<object>)provider.GetService(genericEnumerable);
        }
        /// <summary>
        /// Get an enumeration of services of type <typeparamref name="TService"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        public static IEnumerable<TService> GetServices<TService>(this IServiceProvider provider) {
            return provider.GetServices(typeof(TService)).Cast<TService>();
        }
        /// <summary>
        /// Get service of type <paramref name="serviceType"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        public static object GetRequiredService(this IServiceProvider provider, Type serviceType) {
            if (provider == null) {
                throw new ArgumentNullException("provider");
            }
            if (serviceType == null) {
                throw new ArgumentNullException("serviceType");
            }
            var service = provider.GetService(serviceType);
            if (service == null) {
                throw new InvalidOperationException(string.Format("There is no service of type {0}", serviceType));
            }
            return service;
        }
        /// <summary>
        /// Get service of type <typeparamref name="T"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        public static T GetRequiredService<T>(this IServiceProvider provider) {
            if (provider == null) {
                throw new ArgumentNullException("provider");
            }
            return (T)provider.GetRequiredService(typeof(T));
        }
    }
    public static class NavigationExtensions {
        public static bool Navigate<TView>(this Frame frame) where TView : Page {
            return frame.Navigate(typeof(TView));
        }
        public static bool Navigate<TView, TViewModel>(this Frame frame) where TView : Page {
            return frame.Navigate(typeof(TView), typeof(TViewModel));
        }
    }
    
