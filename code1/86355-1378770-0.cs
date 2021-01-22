public override int GetHashCode()
{
	int mc = //magic constant, usually some prime
	return mc * prop1.GetHashCode() * prop2.GetHashCode * ... * propN.GetHashCode();
}
