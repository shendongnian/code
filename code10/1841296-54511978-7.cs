    public class HealthWithSound : Health
    {
        public AudioSource someAudioSource;
        public AudioClip someClip;
        // Since it is abstract we have to implement Die
        public override void Die()
        {
            // whatever happens here
        }
        // This time we only extend the base's TakeDamage with e.g. sound
        public override void TakeDamage()
        {
            base.TakeDamage();
            someAudioSource.PlayOneShot(someClip);
        }
    }
