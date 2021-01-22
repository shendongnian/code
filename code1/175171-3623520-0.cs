    class CatEntity : Entity, IModifiablePosition
    {
      // Interface method
      public void ModifyPosition(Vector2 blah) { ... }
    ...
    }
    class RobotEntity : Entity, IModifiableShader, IModifiablePosition
    {
    // Interface method
    public void PushShader(RobotEffect bleh) { ... }
    public void ModifyPosition(Matrix blah) { ... }
    ...
    }
    class ShaderModifier : IModifier
    {
      public override void Apply(IModifiableShader obj)
      {
        obj.PushShader(m_furryEffect);
      }
    }
    
    class PositionModifier : IModifier
    {
      public override void Apply(IModifiablePosition obj)
      {
        obj.ModifyPosition(m_mxTranslation);
      }
    }
