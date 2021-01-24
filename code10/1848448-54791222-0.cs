    using System;
    
    public abstract class AManagerTheme<TManager, TControl>
        where TManager : AManagerTheme<TManager, TControl>
        where TControl : AThemeableControl<TManager, TControl>
    {
        public TControl[] ThemableControls;
    
        public virtual void ApplyTheme()
        {
            for (int i = ThemableControls.Length - 1; i >= 0; i--)
            {
                ThemableControls[i].UpdateTheme((TManager) this);
            }           
        }
    }
    
    public abstract class AThemeableControl<TManager, TControl>
        where TManager : AManagerTheme<TManager, TControl>
        where TControl : AThemeableControl<TManager, TControl>
    {
        // Empty implementation; irrelevant for the question.
        public void UpdateTheme(TManager managerTheme) {}
    }
    
    public class NormalTheme : AManagerTheme<NormalTheme, NormalControl>
    {
    }
    
    public class NormalControl : AThemeableControl<NormalTheme, NormalControl>
    {
    }
    
    public class EvilTheme : AManagerTheme<NormalTheme, NormalControl>
    {
    }
    
    public class Test
    {
        static void Main()
        {
            var theme = new EvilTheme
            {
                ThemableControls = new[] { new NormalControl() }
            };
            theme.ApplyTheme();
        }
    }
