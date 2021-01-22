	public class SerializableStopwatch : Stopwatch, ISerializable
	{
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Ticks", ElapsedTicks);
			// .. etc ..
		}
	}
