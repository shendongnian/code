I was planning to add to [Jon Skeet's][1] answer by mentioning that he did not give an answer for public Tweetal(Tweetal t) 
{ 
    a = t.a; 
    b = t.b; 
} 
and warn **not** to implement ICloneable like this
class Tweetal: ICloneable
{
...
  object ICloneable.Clone() 
  { 
    return this.Clone(); 
  }
  public virtual Tweetal Clone()
  {
    return (Tweetal) this.MemberwiseClone();
  }
}
because of [this reason][2] and rather suggest creating Copy(Tweetal objectToCopy)</pre> method cause it's meaning is clearer than the param in the constructor. 
