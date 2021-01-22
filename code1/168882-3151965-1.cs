public class Wrapper
{
	public ValueHolder<int> v1 = 5;
	public ValueHolder<byte> v2 = 8;
}
public struct ValueHolder<T>
	where T : struct
{
	private T value;
	public ValueHolder(T value) { this.value = value; }
	public static implicit operator T(ValueHolder<T> valueHolder) { return valueHolder.value; }
	public static implicit operator ValueHolder<T>(T value) { return new ValueHolder<T>(value); }
}
