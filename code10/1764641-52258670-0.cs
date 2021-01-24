        private void OnNotifyAgentEntityChanged(object sender, EntityChangedEventArgs entityChangedEventArgs)
        {
			this.PublishEvent((TEntity)entityChangedEventArgs.Entity);
		}
		private void PublishEvent(TEntity entity)
		{
			object args = this.GetEventArgs(entity);
			object eventObject = this.GetEventObject(entity);
			MethodInfo publishMethod = eventObject.GetType().GetMethod("Publish");
			publishMethod.Invoke(eventObject, new[] { args });
		}
		private object GetEventArgs(TEntity entity)
		{
			Type viewModelIdentifierEventArgsType = typeof(ViewModelIdentifierEventArgs<>).MakeGenericType(entity.GetType());
			object args = Activator.CreateInstance(viewModelIdentifierEventArgsType, Guid.NewGuid(), entity);
			return args;
		}
		private object GetEventObject(TEntity entity)
		{
			MethodInfo getEventMethod = typeof(IEventAggregator).GetMethod("GetEvent");
			Type entityModifiedEventType = typeof(EntityModifiedEvent<>).MakeGenericType(entity.GetType());
			MethodInfo genericGetEventMethod = getEventMethod.MakeGenericMethod(entityModifiedEventType);
			object eventObject = genericGetEventMethod.Invoke(this.eventAggregator, null);
			return eventObject;
		}
