    using UnityEngine;
    public class Enemy : MonoBehaviour
    {
    public int maxHealth = 40;
    Rigidbody2D rb2d;
    public float speed;
    public float attackRange;
    private float lastAttackTime;
    public float attackDelay;
    private float distanceToTarget;
    public Transform target;
    public float chaseRange;
    public GameObject projectile;
    public float bulletForce;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {       
        if (distanceToTarget < chaseRange)
        {
            //start chasing player
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
            rb2d.velocity = targetDir.normalized * speed;
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }
    private void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < attackRange)
        {
            //check to see if its time to attack again
            if (Time.time > lastAttackTime + attackDelay)
            {
                RaycastHit2D Hit = Physics2D.Raycast(transform.position, transform.up, attackRange, 1 << LayerMask.NameToLayer("Player"));                
                if (Hit)
                {
                    GameObject newBullet = Instantiate(projectile, transform.position, transform.rotation);
                    newBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
                    lastAttackTime = Time.time;
                }
            }
        }
    }
    }
